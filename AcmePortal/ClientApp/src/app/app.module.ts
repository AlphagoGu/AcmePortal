import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ActivityAddComponent } from './Components/activity-add/activity-add.component';
import { ActivityListComponent } from './Components/activity-list/activity-list.component';
import { ActivityService } from './Services/activity.service';

@NgModule({
  declarations: [
    AppComponent,
    ActivityAddComponent,
    ActivityListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ActivityAddComponent, pathMatch: 'full' },
      { path: 'activity-add', component: ActivityAddComponent },
      { path: 'activity-list', component: ActivityListComponent },
    ])
  ],
  providers: [ActivityService],
  bootstrap: [AppComponent]
})
export class AppModule { }
