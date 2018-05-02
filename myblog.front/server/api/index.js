import { Router } from 'express'

import auth from './auth'
import all from './all'

const router = Router()

router.use(auth)
router.use(all)

export default router
