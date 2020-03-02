"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var usa_state_1 = require("../usa-state");
var authorize_guard_1 = require("../../../api-authorization/authorize.guard");
exports.UsaStateRoutes = [
    { path: '', component: usa_state_1.UsaStateBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: usa_state_1.UsaStateCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: usa_state_1.UsaStateCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: usa_state_1.UsaStateDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=usa-state.routes.js.map