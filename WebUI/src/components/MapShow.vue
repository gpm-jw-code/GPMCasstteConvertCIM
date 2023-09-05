<template>
  <div class="map-show border py-2 px-2 d-flex flex-row bg-light">
    <div class="text-start mx-2 py-3" style="width:77px">
      <span>顯示方式</span>
      <b-form-group @change="NameDisplayChangeHandle" class="w-100" v-slot="{ ariaDescribedby }">
        <b-form-radio
          v-model="display_selected"
          :aria-describedby="ariaDescribedby"
          name="some-radios"
          value="Tag"
        >Tag</b-form-radio>
        <b-form-radio
          v-model="display_selected"
          :aria-describedby="ariaDescribedby"
          name="some-radios"
          value="Index"
        >Index</b-form-radio>
      </b-form-group>
      <!-- <b-button @click="UpdateNavPathRender([59,73,71,69,51,53,12])">Test</b-button> -->
    </div>
    <div class="w-100">
      <div class="w-100 d-flex flex-row justify-content-end">
        <span class="p-1">MAP</span>
        <div>
          <b-form-input v-model="map_name" disabled size="sm" :state="map_data.Name!=undefined"></b-form-input>
        </div>
      </div>
      <div v-loading="loading" ref="map" class="map border"></div>
    </div>
  </div>
</template>
  
  <script>
import 'ol/ol.css';
import { Map, View, Feature } from 'ol';
import { Vector as VectorLayer } from 'ol/layer';
import { Vector as VectorSource } from 'ol/source';
import { Point } from 'ol/geom';
import { Circle as CircleStyle, Fill, Stroke, Style, Text, RegularShape, Image } from 'ol/style';
import LineString from 'ol/geom/LineString';
import MapAPI from '@/api/MapAPI'
import bus from '@/event-bus'
import { my_data } from '@/gpm_param.js'
import Notifier from '@/api/NotifyHelper';
export default {
  name: 'MapComponent',
  data() {
    return {
      loading: false,
      map_name: 'Unknown',
      display_selected: "Tag",
      map: new Map(),
      layer_index: {
        station: 1,
        station_line: 2,
        eq_station: 3,
        agv: 4,
        move_path: 5
      },
      map_data: {},
      stations: [],
      agv: {
        current_tag: 51,
        previous_tag: -1
      },
      doubleArrowStyle: new Style({
        stroke: new Stroke({
          color: 'grey',
          width: 3,
          lineDash: null,
        }),
      }),
      NavPathLineStyle: new Style({
        stroke: new Stroke({
          color: 'red',
          width: 8,
          lineDash: null,
        }),
      })
    }
  },
  async mounted() {
    // create a map instance
    this.loading = true;
    setTimeout(() => {
      MapAPI.GetMapFromLocal().then((map) => {
        this.loading = false;
        if (map == undefined) {
          Notifier.Danger('圖資取得失敗(後端伺服器異常)', 'top', 3000);
        }
        else if (map.Points == undefined) {
          Notifier.Danger('圖資取得失敗(AGVS伺服器異常)', 'top', 3000);
        }
        else {
          Notifier.Success('Success Fetch Map Data From Server.', 'top', 2000);

          this.map_data = map;
          this.map_name = map.Name;
          this.station_features = [];
          Object.keys(map.Points).forEach(index => {
            var Graph = map.Points[index].Graph

            this.stations.push(
              {
                index: parseInt(index),
                tag: map.Points[index].TagNumber,
                feature:
                  new Feature({
                    geometry: new Point([Graph.X * 1000, Graph.Y * -1000]),
                    //   name: Graph.Display,
                    name: index,
                  })
              }

            );
          })

          this.Render();
          bus.on('/agv_current_tag', (tag) => {

            if (tag != 0 && this.agv.previous_tag != tag) {
              this.agv.current_tag = tag;
              this.AGV_Feature.setGeometry(new Point(this.agv_position));
              this.AGV_Layer.getSource().changed();
            }
            this.agv.previous_tag = tag;
          })

        }

      });

    }, 100);

  },
  computed: {
    station_features() {
      let features = [];
      this.stations.forEach(st => {
        if (st.feature != undefined)
          features.push(st.feature);
      });
      return features;
    },
    Station_Layer() {
      return this.map.getLayers().item(this.layer_index.station);
    },
    Line_Layer() {
      return this.map.getLayers().item(this.layer_index.station_line);
    },
    AGV_Layer() {
      return this.map.getLayers().item(this.layer_index.agv);
    },
    Nav_Path_Layer() {
      return this.map.getLayers().item(this.layer_index.move_path);
    },
    AGV_Feature() {
      return this.AGV_Layer.getSource().getFeatures()[0];
    },
    agv_position() {
      var station = this.stations.find(st => st.tag == this.agv.current_tag);
      console.info(this.agv.current_tag, station);
      if (station == undefined)
        return [0, 0];
      else {
        return station.feature.getGeometry().getCoordinates();
      }
    }
  },
  methods: {
    TestChanged() {
      this.AGV_Feature.setGeometry(new Point(this.agv.position));
      this.AGV_Layer.getSource().changed();
    },
    Render() {

      const lineFeatures = this.CreateLineFeaturesOfPath();
      this.map = new Map({
        target: this.$refs.map,
        layers: [
          // add a vector layer with no source
          new VectorLayer({//0
            source: new VectorSource(),
          }),
          // add a vector layer with three points
          new VectorLayer({//1
            source: new VectorSource({
              features: this.station_features
            }),
            zIndex: 2
          }), new VectorLayer({//3
            source: new VectorSource({
              features: lineFeatures
            }),
            style: this.doubleArrowStyle,
            zIndex: 1
          }),
          new VectorLayer({//2
            source: new VectorSource(),
          }),

          new VectorLayer({//4
            source: new VectorSource({
              features: [
                new Feature({
                  geometry: new Point(this.agv_position),
                  name: 'AGV'
                })
              ],
            }
            ),
            zIndex: 4
          }),
          new VectorLayer({//5:導航任務路徑顯示
            source: new VectorSource({
              features: [new Feature({
                geometry: new Point(this.agv_position),
                name: 'AGV2'
              })]
            }),
            style: this.NavPathLineStyle
          }),
        ],
        view: new View({
          center: [0, 0],
          zoom: 6,
        }),
      });

      // add text to each point

      this.StationStyleRender();
      this.AGVStyleRender();

      //this.Line_Layer.getSource().addFeature(lineFeature);
    },
    CreateLineFeaturesOfPath() {
      // 创建一条线要素，连接两个点要素
      var lineFeatures = [];
      Object.keys(this.map_data.Points).forEach(index_str => {
        var index = parseInt(index_str)
        var current_station = this.stations.find(st => st.index == index);
        var targets = this.map_data.Points[index_str].Target;
        Object.keys(targets).forEach(index_str => {
          var _index = parseInt(index_str)
          //找到
          var station_link = this.stations.find(st => st.index == _index);
          if (station_link != undefined) {

            let lineFeature = new Feature({
              geometry: new LineString([current_station.feature.getGeometry().getCoordinates(), station_link.feature.getGeometry().getCoordinates()]),
            });
            lineFeatures.push(lineFeature);
          }
        })

      })

      return lineFeatures;
    },
    StationStyleRender() {
      this.map.getLayers().item(1).getSource().getFeatures().forEach((feature) => {
        var station = this.stations.find(st => st.feature == feature);
        var showTagNumber = this.display_selected == 'Tag';
        const name = (showTagNumber ? station.tag : station.index) + '';
        var nameInt = parseInt(name);
        var isEQStation = nameInt % 2 == 0
        feature.setStyle(new Style({
          image: new CircleStyle({
            radius: 10,
            fill: new Fill({
              color: isEQStation ? 'orange' : 'blue',
            }),
            stroke: new Stroke({
              color: 'black',
              width: 2,
            }),
          }),
          text: new Text({
            text: name,
            offsetX: -18,
            offsetY: -18,
            font: 'bold 18px sans-serif',
            fill: new Fill({
              color: showTagNumber ? 'black' : 'grey'
            })
          }),
        }));
      });

      this.Station_Layer.getSource().changed();
    },

    AGVStyleRender() {
      var agv_feature = this.AGV_Feature;
      const name = agv_feature.get('name');
      agv_feature.setStyle(new Style({
        image: new RegularShape({
          radius: 15,
          fill: new Fill({
            color: 'rgb(0, 204, 0)',
          }),
          stroke: new Stroke({
            color: 'black',
            width: 2,
          }),
          angle: 0,
          points: 4
        }),
        text: new Text({
          text: name,
          offsetX: 25,
          offsetY: -25,
          font: 'bold 18px sans-serif',
          fill: new Fill({
            color: 'green'
          })
        }),
      }));

    },
    NameDisplayChangeHandle() {
      this.StationStyleRender();
    },
    ClearNavPath() {
      let source = this.Nav_Path_Layer.getSource();
      source.clear(); //把原有的feature移除
    },
    UpdateNavPathRender(tags = []) {

      my_data.test = Date.now();
      this.ClearNavPath();
      if (tags.length == 0) {
        return;
      }
      let source = this.Nav_Path_Layer.getSource();
      var features = this.CreateLineFeaturesOfNavPath(tags);
      features.forEach(feature => {
        source.addFeature(feature)
      })
      source.changed();
    },
    CreateLineFeaturesOfNavPath(tags = []) {
      // 创建一条线要素，连接两个点要素
      var lineFeatures = [];

      for (let index = 0; index < tags.length; index++) {
        const tag = tags[index];
        const next_tag = tags[index + 1];
        //找出feature
        if (next_tag != undefined) {

          var current_station = this.stations.find(st => st.tag == tag);
          var next_station = this.stations.find(st => st.tag == next_tag);
          let lineFeature = new Feature({
            geometry: new LineString([current_station.feature.getGeometry().getCoordinates(), next_station.feature.getGeometry().getCoordinates()]),
          });
          lineFeatures.push(lineFeature);

        }
      }
      console.log(lineFeatures);
      return lineFeatures;
    }
  },
};
  </script>
  
<style scoped>
.map-show {
}

.map {
  height: 95%;
  width: 100%;
}
</style>
  