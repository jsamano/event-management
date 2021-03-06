import { Component, OnInit } from '@angular/core';
import { EventManagementApiClient, Event } from '../services/event-management-api.client';
import { ActivatedRoute, Router } from '@angular/router';
import { PageAlertService } from '../services/page-alert.service';
import { SessionService } from '../services/session.service';

@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css']
})
export class EventEditComponent implements OnInit {

  model : Event = new Event();

  constructor(
    private apiClient : EventManagementApiClient,
    private session: SessionService,
    private route: ActivatedRoute,
    private router: Router,
    private alertService: PageAlertService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.apiClient.events_GetEvent(id)
        .subscribe((evt: Event) => this.model = evt);
    }
  }

  submit() {
    const isNew = !this.model.id;
    if (isNew) {
      this.apiClient.events_CreateEvent(this.model)
        .subscribe((event: Event) => {
          this.alertService.showSaveSuccessAlert();
          this.session.setCurrentEvent(event);
          this.router.navigate(['/events', event.id]);
        });
    } else {
      this.apiClient.events_UpdateEvent(this.model.id, this.model)
        .subscribe(() => this.alertService.showSaveSuccessAlert());
    }
  }
}
