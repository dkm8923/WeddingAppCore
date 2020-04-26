"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var app_settings_1 = require("../app-settings");
var authorize_guard_1 = require("../../../../api-authorization/authorize.guard");
exports.AppSettingsRoutes = [
    { path: '', component: app_settings_1.AppSettingsBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: app_settings_1.AppSettingsCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: app_settings_1.AppSettingsCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: app_settings_1.AppSettingsDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=app-settings.routes.js.map