$session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
$session.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36"
$session.Cookies.Add((New-Object System.Net.Cookie("connect.sid", "s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI", "/", "127.0.0.1")))
$session.Cookies.Add((New-Object System.Net.Cookie("io", "TPrw6Q8Aol3EBu1YAAAP", "/", "127.0.0.1")))
Invoke-WebRequest -UseBasicParsing -Uri "http://127.0.0.1:6600/mission/request?CarName=AGV_1&AGVID=1&Action=Move&FromStation=35&FromSlot=1&ToStation=&ToSlot=1&Priority=5&RepeatTime=1&CSTID=" `
-WebSession $session `
-Headers @{
"Accept"="text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
  "Accept-Encoding"="gzip, deflate, br"
  "Accept-Language"="zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7"
  "Cache-Control"="max-age=0"
  "If-None-Match"="W/`"9-jzx2EgBMkpY+6IaWT/5VN/h8c9g`""
  "Sec-Fetch-Dest"="document"
  "Sec-Fetch-Mode"="navigate"
  "Sec-Fetch-Site"="none"
  "Sec-Fetch-User"="?1"
  "Upgrade-Insecure-Requests"="1"
  "sec-ch-ua"="`"Not_A Brand`";v=`"99`", `"Google Chrome`";v=`"109`", `"Chromium`";v=`"109`""
  "sec-ch-ua-mobile"="?0"
  "sec-ch-ua-platform"="`"Windows`""
}