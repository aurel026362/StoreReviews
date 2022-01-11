import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { CanActivate, Router } from "@angular/router";
import { LoginComponent } from "../login/login.component";
import { AuthService } from "../services/auth.service";


@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(
        private authService: AuthService,
        private router: Router,
        public dialog: MatDialog) {

    }

    canActivate(): boolean {
        if (!this.authService.isAuthemticated) {
            this.router.navigate(['../']);

            const dialogRef = this.dialog.open(LoginComponent,
                {
                    width: '50%',
                    minWidth: '400px',
                    maxWidth: '620px'
                });

            dialogRef.afterClosed().subscribe(result => {
            });
        }
        return true;
    }
}