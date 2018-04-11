import Vue from 'vue'
import Router from 'vue-router'
import MainFrame from './MainFrame'
import Login from './Login'
import Posts from './Posts'
import PostsAll from './PostsAll'
import PostsByTag from './PostsByTag'
import PostsByCat from './PostsByCat'
import NewPost from './NewPost'
// import store from '../store'

Vue.use(Router)

const router = new Router({
  routes: [
    {
      path: '/login',
      component: Login,
      name: 'login',
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/',
      component: MainFrame,
      name: 'home',
      meta: {
        requiresAuth: false
      },
      children: [
        {
          path: 'posts',
          component: Posts,
          meta: {
            requiresAuth: false
          },
          children: [
            {
              path: '',
              component: PostsAll,
              name: 'posts'
            },
            {
              path: 'tag/:tagname',
              component: PostsByTag
            },
            {
              path: 'category/:catname',
              component: PostsByCat
            }
          ]
        },
        {
          path: 'post/:postid',
          component: Posts,
          name: 'post',
          meta: {
            requiresAuth: false
          }
        },
        {
          path: 'newpost',
          component: NewPost,
          name: 'newpost',
          meta: {
            requiresAuth: false
          }
        }
      ]
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.path === '/') {
    router.push({ path: '/posts' })
  }
  next()
  // if (to.matched.some(record => record.meta.requiresAuth)) {
  //   if (store.state.auth.logined !== true) {
  //     next({
  //       path: '/account/login',
  //       query: {
  //         redirect: to.fullPath
  //       }
  //     })
  //   } else {
  //     next()
  //   }
  // } else {
  //   next()
  // }
})

export default router
