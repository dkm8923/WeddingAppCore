"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var reference_type_1 = require("../reference-type");
var authorize_guard_1 = require("../../../../api-authorization/authorize.guard");
exports.ReferenceTypeRoutes = [
    { path: '', component: reference_type_1.ReferenceTypeBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: reference_type_1.ReferenceTypeCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: reference_type_1.ReferenceTypeCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: reference_type_1.ReferenceTypeDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=reference-type.routes.js.map