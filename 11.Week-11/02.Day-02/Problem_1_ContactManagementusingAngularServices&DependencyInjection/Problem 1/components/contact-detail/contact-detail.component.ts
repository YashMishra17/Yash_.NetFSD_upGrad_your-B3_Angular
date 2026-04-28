/*Week-11 (DAY-2) Hands-On

Problem 1: Contact Management using Angular Services & Dependency Injection (Level-1 with CRUD Basics)

 Problem
In Angular applications, handling shared data across components without services leads to poor maintainability and code duplication. To solve this, Angular provides Dependency Injection (DI) and Services.
Learners must implement a Contact Management module where all contact-related operations are handled through a centralized service.

 Scenario
You are building a Contact Management system where users can:
View all contacts 
Add a new contact 
View details of a specific contact 
All operations must be handled through a ContactService, which is injected into components using Angular’s DI mechanism.

Requirements
🔹 Functional Requirements
1. Contact Model
Create a model/interface:
export interface Contact {
  id: number;
  name: string;
  email: string;
  phone: string;
}

2. ContactService (Core Focus)
Create a service with the following responsibilities:
Maintain an in-memory contact list
Provide methods:
getContacts(): Contact[]
Returns all contacts 
addContact(contact: Contact): void
Adds a new contact to the list 
getContactById(id: number): Contact | undefined
Returns a single contact based on Id 

3. Component Integration
Create at least two components:
 ContactListComponent
Inject ContactService 
Display all contacts using *ngFor 
ContactDetailComponent
Accept id (hardcoded or via route param for Level-1) 
Use service method getContactById() 
Display selected contact details 

4. Add Contact UI (Basic)
Create a simple form (can be template-driven) 
Call addContact() from the service 
Update the contact list dynamically 

Technical Constraints
Angular (15+ / Angular 21 preferred) 
Use @Injectable({ providedIn: 'root' }) 
No backend/API (in-memory array only) 
No routing required (optional for Level-1) 
Keep UI simple (no validations required initially) 

Expectations
Proper use of Dependency Injection 
Service acts as a single source of truth 
Clean separation: 
oComponent → UI logic 
oService → Business/data logic 
Correct implementation of: 
oAdd operation 
oFetch by Id 

🎓 Learning Outcomes
By completing this task, learners will:
1.Understand how Angular services manage shared state 
2.Implement Dependency Injection properly 
3.Perform basic CRUD-like operations (Create + Read) 
4.Learn how to: 
oAdd data via service 
oRetrieve specific data by Id 
5.Build a foundation for: 
oHTTP services 
oBackend integration 
oRouting-based detail views */

///////////////////////////////////////////////////////////////////////////////


import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  templateUrl: './contact-detail.component.html'
})
export class ContactDetailComponent implements OnInit {

  contact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnInit(): void {
    this.contact = this.contactService.getContactById(1);
  }
}
