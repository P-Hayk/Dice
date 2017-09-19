import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistrationComponent } from './registration.component';


const LoginRoutes: Routes = [
    {
        path: '',
        component: RegistrationComponent,
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(LoginRoutes)],
    exports: [RouterModule]
})

export class RegistrationRoutingModule { }