"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var nav_link_section_1 = require("../nav-link-section");
var authorize_guard_1 = require("../../../../api-authorization/authorize.guard");
exports.NavLinkSectionRoutes = [
    { path: '', component: nav_link_section_1.NavLinkSectionBaseComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'create', component: nav_link_section_1.NavLinkSectionCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'edit/:id', component: nav_link_section_1.NavLinkSectionCreateEditComponent, canActivate: [authorize_guard_1.AuthorizeGuard] },
    { path: 'delete/:id', component: nav_link_section_1.NavLinkSectionDeleteComponent, canActivate: [authorize_guard_1.AuthorizeGuard] }
];
//# sourceMappingURL=nav-link-section.routes.js.map