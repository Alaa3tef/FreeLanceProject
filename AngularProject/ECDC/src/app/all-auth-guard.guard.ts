import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from 'Services/login.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AllAuthGuardGuard implements CanActivate {
  User: any = this._LoginService.currentUser.getValue();
  constructor(private _LoginService: LoginService, private router: Router) {

  }


  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if ((this.User != null)) {
      console.log("auth gaaaaaaarddddddddd")
      console.log(this.User.Role)
      // console.log(this.User.Role=="Radio")

      return true;
    }
    else {
      console.log("this.User")
      console.log(this.User)
      this.router.navigate(['/Login'])
      return false;
    }
  }

}
