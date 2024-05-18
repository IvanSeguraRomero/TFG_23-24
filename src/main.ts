import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'

// import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const pinia = createPinia()
const app = createApp(App)

const vuetify = createVuetify({
  components,
  directives
})

app.use(pinia)
app.use(router)

app.mixin({
  computed: {
    username(this: any) {
      // We will see what params is shortly
      return this.$route.params.username
    }
  },
  methods: {
    goBack(this: any) {
      window.history.length > 1 ? this.$router.go(-1) : this.$router.push('/')
    }
  }
})
app.use(vuetify)
app.mount('#app');
// app.mount('#app');
