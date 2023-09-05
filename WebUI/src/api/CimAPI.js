import WebSocketHelp from "./WebSocketHepler";
import param from "@/gpm_param";

export function ClearAlarm(){
    SendUICmd('clear_alarm');
}

export function PortTypeChange(port_id,type_){
    SendUICmd(`port_type_change:${port_id}:${type_}`)
}

export function EventReport(port_id,event_str){
    SendUICmd(`event_report:${port_id}:${event_str}`);
}

function SendUICmd(cmd){
        var ws = new WebSocketHelp('ui',param.websocket_url)
        ws.Connect()
        ws.wssocket.onopen=(ev)=>{
            console.info('open');
            ws.wssocket.send(cmd);
            
        }
        ws.wssocket.onmessage=(ev)=>{
            console.info('ev:',ev.data);
            ws.Close()
        }
}