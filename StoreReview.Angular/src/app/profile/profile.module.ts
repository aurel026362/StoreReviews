import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatExpansionModule } from '@angular/material/expansion';
import { Routes, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { CompanyService } from '../services/company.service';
import { ReviewsModule } from '../shared/reviews/reviews.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LinkifyModule } from '../shared/pipe/linkify.module';
import { ProfileComponent } from './profile.component';
import { MatListModule } from '@angular/material/list';
import { UserActionsComponent } from './user-actions/user-actions.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProfileService } from './profile.service';

const routes: Routes = [
    {
        path: '',
        component: ProfileComponent,
        children:
            [
                {
                    path: '',
                    component: UserActionsComponent
                },
                {
                    path: 'edit',
                    component: EditProfileComponent
                }
            ]
    }
];

@NgModule({
    imports: [
        MatInputModule,
        MatExpansionModule,
        CommonModule,
        MatButtonModule,
        ReviewsModule,
        MatDividerModule,
        MatIconModule,
        MatListModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        MatProgressSpinnerModule,
        LinkifyModule
    ],
    declarations: [
        ProfileComponent,
        EditProfileComponent,
        UserActionsComponent
    ],
    providers: [
        ProfileService
    ]
})
export class ProfileModule { }
