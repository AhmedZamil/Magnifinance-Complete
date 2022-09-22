import { Component, OnInit } from '@angular/core';
import { ModalService } from './modal.service';
import * as signalR from '@aspnet/signalr';
import { NotificationCountResult, NotificationResult } from './notification';
import { NotificationService } from './notification.service';
import { environment } from './environment';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

    notification: NotificationCountResult;
    messages: Array<NotificationResult>;
    errorMessage = '';

    constructor(private notificationService: NotificationService, private modalService: ModalService) { }
    isExpanded = false;

    ngOnInit() {
        this.getNotificationCount();
        const connection = new signalR.HubConnectionBuilder()
            .configureLogging(signalR.LogLevel.Information)
            .withUrl('/notify')
            .build();

        connection.start().then(function () {
            console.log('SignalR Connected!');
        }).catch(function (err) {
            return console.error(err.toString());
        });

        connection.on("BroadcastMessage", () => {
            this.getNotificationCount();
        });
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    getNotificationCount() {
        this.notificationService.getNotificationCount().subscribe(
            notification => {
                this.notification = notification;
            },
            error => this.errorMessage = <any>error
        );
    }

    getNotificationMessage() {
        this.notificationService.getNotificationMessage().subscribe(
            messages => {
                this.messages = messages;
            },
            error => this.errorMessage = <any>error
        );
    }

    deleteNotifications(): void {
        if (confirm(`Are you sure want to delete all notifications?`)) {
            this.notificationService.deleteNotifications()
                .subscribe(
                    () => {
                        this.closeModal();
                    },
                    (error: any) => this.errorMessage = <any>error
                );
        }
    }
    openModal() {
        this.getNotificationMessage();
        this.modalService.open('custom-modal');
    }

    closeModal() {
        this.modalService.close('custom-modal');
    }
}