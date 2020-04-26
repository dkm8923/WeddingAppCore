"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var application_1 = require("../application");
var authorize_guard_1 = require("../../../../api-authorization/authorize.guard");
exports.ApplicationRoutes = [
    { path: '', component: application_1.ApplicationBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: application_1.ApplicationCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: application_1.ApplicationCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: application_1.ApplicationDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=application.routes.js.map