import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { PlayerRequestService } from "app/shared/player.request.service";
import { CookieService } from 'angular2-cookie/core';

@Component({
    selector: 'registration',
    templateUrl: './registration.component.html'
})

export class RegistrationComponent implements OnInit, OnDestroy {

    constructor(
        private PlayerRequestService: PlayerRequestService,
        private cookieService: CookieService,
        private route: Router) {
    }

    public regUserName: string;
    public regPass: string;
    public regRepeatePass:string;
    public FirstName:string;
    public LastName:string;

    ngOnDestroy(): void {

    }
    ngOnInit(): void {

    }

    registration() {
        if(this.regPass!=this.regRepeatePass){
            console.log("ERROR Password!=RepeatePassword");
            return;
        }
        let data =
            {
                UserName: this.regUserName,
                PasswordHash: this.regPass,
                FirstName:this.FirstName,
                LastName:this.LastName
            }
        this.PlayerRequestService.registrationPlayer(data).subscribe(
            result => {
                //localStorage.setItem('token', result.ResponseObject.Token);
                //localStorage.setItem('Id', result.ResponseObject.PlayerId);                
                this.cookieService.putObject('a', result.ResponseObject);
                if(result.ResponseCode==0)
                    this.route.navigate(['desk']);
                else{
                    this.cookieService.remove('a');
                    this.route.navigate(['login']);
                }

            });
    }

}