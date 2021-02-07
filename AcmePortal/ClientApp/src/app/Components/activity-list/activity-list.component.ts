import { Component, OnInit } from '@angular/core';
import { ActivityService } from '../../Services/activity.service';
import { Activity } from '../Models/activity';

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html',
  styleUrls: ['./activity-list.component.css']
})
export class ActivityListComponent implements OnInit {

  userActivities: Activity[];

  constructor(private activityService: ActivityService) { }


  ngOnInit() {
    this.loadUserActivities();
  }

  loadUserActivities() {
    //call API to store data once all validated with no issue
    this.activityService.getAllRecords().subscribe(res => {
      this.userActivities = res;
    });
  }
}
