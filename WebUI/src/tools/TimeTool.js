import moment from "moment/moment";

export function FormatTimeString(time_str,format='yyyy/MM/DD HH:mm:ss'){
    return moment(time_str).format(format);
}