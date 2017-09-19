import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
        path: 'login',
        loadChildren: './login/login.module#LoginModule'
    },
    {
        path: 'desk',
        loadChildren: './desk/desk.module#DeskModule'
    },
    {
        path: 'game',
        loadChildren: './game/game.module#GameModule'
    },
    {
        path: 'registration',
        loadChildren: './registration/registration.module#RegistrationModule'
    },
    {
        path: '',
        redirectTo: 'registration',
        pathMatch: 'full'
    },
    {
        path: '**',
        redirectTo: 'registration',
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
