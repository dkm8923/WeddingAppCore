"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var usa_state_base_component_1 = require("./usa-state-base/usa-state-base.component");
var usa_state_delete_component_1 = require("./usa-state-delete/usa-state-delete.component");
var usa_state_create_edit_component_1 = require("./usa-state-create-edit/usa-state-create-edit.component");
var authorize_guard_1 = require("../../../api-authorization/authorize.guard");
exports.UsaStateRoutes = [
    { path: '', component: usa_state_base_component_1.UsaStateBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: usa_state_create_edit_component_1.UsaStateCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: usa_state_create_edit_component_1.UsaStateCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: usa_state_delete_component_1.UsaStateDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=usa-state.routes.js.map