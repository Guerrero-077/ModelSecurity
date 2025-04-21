import { menuItems } from './menu/routerMenu.js';

import { router } from './route/router.js';

window.addEventListener('hashchange', router);
window.addEventListener('load', router);
