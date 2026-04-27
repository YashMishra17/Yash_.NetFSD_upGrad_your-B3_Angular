import { Component } from '@angular/core';

@Component({
  selector: 'app-contact-list',
  imports: [],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
  searchText = '';
  showLimit = 5;

  contacts = [
    { name: 'john doe', email: 'JOHN@MAIL.COM', phone: '9876543210', status: true },
    { name: 'jane smith', email: 'JANE@MAIL.COM', phone: '9123456780', status: false },
    { name: 'alex ray', email: 'ALEX@MAIL.COM', phone: '9988776655', status: true },
    { name: 'emma watson', email: 'EMMA@MAIL.COM', phone: '9090909090', status: true },
    { name: 'liam neeson', email: 'LIAM@MAIL.COM', phone: '8888888888', status: false },
    { name: 'noah centineo', email: 'NOAH@MAIL.COM', phone: '7777777777', status: true },
    { name: 'olivia wilde', email: 'OLIVIA@MAIL.COM', phone: '6666666666', status: false },
    { name: 'ava brown', email: 'AVA@MAIL.COM', phone: '5555555555', status: true },
    { name: 'mia khalifa', email: 'MIA@MAIL.COM', phone: '4444444444', status: false },
    { name: 'logan paul', email: 'LOGAN@MAIL.COM', phone: '3333333333', status: true }
  ];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }

  toggleLimit() {
    this.showLimit = this.showLimit === 5 ? this.contacts.length : 5;
  }

}
