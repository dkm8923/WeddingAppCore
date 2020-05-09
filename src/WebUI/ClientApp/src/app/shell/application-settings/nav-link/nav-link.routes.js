"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var nav_link_1 = require("../nav-link");
var authorize_guard_1 = require("../../../../api-authorization/authorize.guard");
exports.NavLinkRoutes = [
    { path: '', component: nav_link_1.NavLinkBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: nav_link_1.NavLinkCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: nav_link_1.NavLinkCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: nav_link_1.NavLinkDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=nav-link.routes.js.map