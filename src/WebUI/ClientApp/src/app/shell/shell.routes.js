"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var application_settings_base_component_1 = require("./application-settings/application-settings-base/application-settings-base.component");
var app_settings_routes_1 = require("./application-settings/app-settings/app-settings.routes");
var application_routes_1 = require("./application-settings/application/application.routes");
var reference_type_routes_1 = require("./application-settings/reference-type/reference-type.routes");
var authorize_guard_1 = require("../../api-authorization/authorize.guard");
exports.ShellRoutes = [
    { path: '', component: application_settings_base_component_1.ApplicationSettingsBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    //{ path: 'application', component: ApplicationBaseComponent, canActivate: [AuthorizeGuard] },
    { path: 'app-settings', children: app_settings_routes_1.AppSettingsRoutes, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'application', children: application_routes_1.ApplicationRoutes, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'reference-type', children: reference_type_routes_1.ReferenceTypeRoutes, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=shell.routes.js.map