import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { PlayerRequestService } from "app/shared/player.request.service";
import { CookieService } from 'angular2-cookie/core';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit, OnDestroy {

    constructor(
        private PlayerRequestService: PlayerRequestService,
        private cookieService: CookieService,
        private route: Router) {
    }

    public loginUserName: string;
    public loginPass: string;

    ngOnDestroy(): void {

    }
    ngOnInit(): void {

    }

    login() {
        let data =
            {
                UserName: this.loginUserName,
                Password: this.loginPass
            }
        this.PlayerRequestService.loginPlayer(data).subscribe(
            result => {
                localStorage.setItem('token', result.ResponseObject.Token);
                localStorage.setItem('Id', result.ResponseObject.PlayerId);                
                this.cookieService.putObject('a', result.ResponseObject);

                this.route.navigate(['desk']);

            });
    }

}