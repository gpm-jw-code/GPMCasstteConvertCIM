using CommunityToolkit.HighPerformance.Buffers;
using System.ComponentModel;
using Secs4Net.Sml;
namespace Secs4Net;


public class PrimaryMessageWrapper : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private readonly SemaphoreSlim _semaphoreSlim = new(initialCount: 1);
    private readonly WeakReference<SecsGem> _secsGem;

    private string _PrimaryMessageSML;
    private string _SecondaryMessageSML;
    private SecsMessage _PrimaryMessage;
    private SecsMessage? _SecondaryMessage;
    public int Id { get; }
    public string PrimaryMessageSML
    {
        get => _PrimaryMessageSML;
        private set
        {
            _PrimaryMessageSML = value;
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PrimaryMessageSML"));
            }
        }
    }
    public string SecondaryMessageSML
    {
        get=>_SecondaryMessageSML;
        private set
        {
            _SecondaryMessageSML = value;
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SecondaryMessageSML"));
            }
        }
    }

    public SecsMessage PrimaryMessage
    {
        get => _PrimaryMessage;
        set
        {
            _PrimaryMessage = value;
            if (_PrimaryMessage != null)
            {
                PrimaryMessageSML = _PrimaryMessage.ToSml();
            }
        }
    }
    public SecsMessage? SecondaryMessage
    {
        get => _SecondaryMessage;
        set
        {
            _SecondaryMessage = value;

            if (_SecondaryMessage != null)
            {
                SecondaryMessageSML = _SecondaryMessage.ToSml();
            }
        }
    }
    public PrimaryMessageWrapper()
    {

    }
    internal PrimaryMessageWrapper(SecsGem secsGem, SecsMessage primaryMessage, int id)
    {
        _secsGem = new WeakReference<SecsGem>(secsGem);
        PrimaryMessage = primaryMessage;
        Id = id;
    }

    /// <summary>
    /// If the message has already replied, method will return false.
    /// </summary>
    /// <param name="replyMessage">Reply S9F7 if parameter is null</param>
    /// <returns>true, if reply success.</returns>
    public async Task<bool> TryReplyAsync(SecsMessage? replyMessage = null, CancellationToken cancellation = default)
    {
        if (!PrimaryMessage.ReplyExpected)
        {
            throw new SecsException("The message does not need to reply");
        }

        if (!_secsGem.TryGetTarget(out var secsGem))
        {
            throw new SecsException("Hsms connector loss, the message has no chance to reply via the ReplyAsync method");
        }

        if (replyMessage is null)
        {
            var headerBytes = new byte[10];
            var buffer = new MemoryBufferWriter<byte>(headerBytes);
            new MessageHeader
            {
                DeviceId = secsGem.DeviceId,
                ReplyExpected = PrimaryMessage.ReplyExpected,
                S = PrimaryMessage.S,
                F = PrimaryMessage.F,
                MessageType = MessageType.DataMessage,
                Id = Id
            }.EncodeTo(buffer);
            replyMessage = new SecsMessage(9, 7, replyExpected: false)
            {
                Name = "Unknown Message",
                SecsItem = Item.B(headerBytes),
            };
        }
        else
        {
            replyMessage.ReplyExpected = false;
        }

        await _semaphoreSlim.WaitAsync(cancellation).ConfigureAwait(false);
        try
        {
            if (SecondaryMessage is not null)
            {
                return false;
            }

            int id = replyMessage.S == 9 ? MessageIdGenerator.NewId() : Id;
            await secsGem.SendDataMessageAsync(replyMessage, id, cancellation).ConfigureAwait(false);
            SecondaryMessage = replyMessage;
            return true;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public sealed override string ToString() => PrimaryMessage.ToString();
}
