import {useRouterStore} from './router'

let router=useRouterStore();

export default function () {
    // 可以在此处执行 action
    router.generateRouter()
  }