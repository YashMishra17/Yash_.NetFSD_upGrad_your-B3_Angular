import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search',
  pure: false   // REQUIRED for live filtering
})
export class SearchPipe implements PipeTransform {

  transform(contacts: any[], searchText: string): any[] {

    // Guard clauses
    if (!contacts) return [];
    if (!searchText || searchText.trim() === '') return contacts;

    const text = searchText.toLowerCase().trim();

    return contacts.filter(contact => {
      const name = contact.name?.toLowerCase() || '';
      const email = contact.email?.toLowerCase() || '';

      return name.includes(text) || email.includes(text);
    });
  }

}