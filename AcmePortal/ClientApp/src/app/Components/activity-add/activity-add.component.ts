import { Component, OnInit } from '@angular/core';
import { Activity } from '../Models/activity';
import { ActivityService } from '../../Services/activity.service';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-activity-add',
  templateUrl: './activity-add.component.html',
  styleUrls: ['./activity-add.component.css']
})
export class ActivityAddComponent implements OnInit {

  activities = ['Movie night', 'Axe throwing', 'Ice skating'];

  model = new Activity();

  constructor(private activityService: ActivityService, private router: Router) { }

  ngOnInit() {
  }

  signUpActivity() {
    //call API to store data once all validated with no issue
    this.activityService.addNewSignUp(this.model).subscribe(res => {
      if (res == 0) {
        this.router.navigateByUrl('activity-list');
      }
    });
  }

  validate() {
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }
    else {
      this.signUpActivity();
    }
    form.classList.add('was-validated');
  }

}
