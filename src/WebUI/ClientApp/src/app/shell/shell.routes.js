"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var application_settings_base_component_1 = require("./application-settings/application-settings-base/application-settings-base.component");
var authorize_guard_1 = require("../../api-authorization/authorize.guard");
exports.ShellRoutes = [
    { path: '', component: application_settings_base_component_1.ApplicationSettingsBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] } //,
    //{ path: 'create', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
    //{ path: 'edit/:id', component: UsaStateCreateEditComponent, canActivate: [AuthorizeGuard] },
    //{ path: 'delete/:id', component: UsaStateDeleteComponent, canActivate: [AuthorizeGuard] }
];
//# sourceMappingURL=shell.routes.js.map