import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRouteGuard } from '../../src/shared/auth/auth-route-guard';
import { AppComponent } from './app.component';
// import {About} from './about/about.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StudentComponent } from './student/student.component';
import { TeachersComponent } from './teachers/teachers.component';
import { DisbursementsComponent } from './disbursements/disbursements.component'
import { CollectionsComponent } from './collections/collections.component';
import {FeeManagementComponent} from './fee-management/fee-management.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    {
                        path: 'home',
                        loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path: 'about',
                        loadChildren: () => import('./about/about.module').then((m) => m.AboutModule),
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path: 'users',
                        loadChildren: () => import('./users/users.module').then((m) => m.UsersModule),
                        data: { permission: 'Pages.Users' },
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path: 'roles',
                        loadChildren: () => import('./roles/roles.module').then((m) => m.RolesModule),
                        data: { permission: 'Pages.Roles' },
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path: 'tenants',
                        loadChildren: () => import('./tenants/tenants.module').then((m) => m.TenantsModule),
                        data: { permission: 'Pages.Tenants' },
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path: 'update-password',
                        loadChildren: () => import('./users/users.module').then((m) => m.UsersModule),
                        canActivate: [AppRouteGuard]
                    },
                    {
                        path:'dashboard',
                        canActivate: [AppRouteGuard],
                        component: DashboardComponent
                    },
                    {
                        path:'student',
                        canActivate: [AppRouteGuard],
                        component: StudentComponent,
                    },
                    {
                        path:'teacher',
                        canActivate: [AppRouteGuard],
                        component:TeachersComponent,
                    },
                    {
                        path:'feesManagement',
                        canActivate: [AppRouteGuard],
                       component:FeeManagementComponent,
                    },
                    {
                        path: 'collections',
                        canActivate: [AppRouteGuard],
                        component: CollectionsComponent
                    },
                    {
                        path:'disbursements',
                        canActivate: [AppRouteGuard],
                        component: DisbursementsComponent, 
                    }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
