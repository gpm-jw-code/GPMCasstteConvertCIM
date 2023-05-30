import axios from 'axios'
import param from '@/gpm_param'
var axios_entity = axios.create({
  baseURL: param.backend_host,
})

const MapAPI = {
  GetMapFromLocal() {
    return axios_entity
      .get('api/Map')
      .then((ret) => {
        return ret.data
      })
      .catch((err) => {
        return undefined
      })
  },
}

export default MapAPI
