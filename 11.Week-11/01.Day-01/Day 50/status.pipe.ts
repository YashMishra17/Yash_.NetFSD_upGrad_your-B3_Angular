import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'status'
})
export class StatusPipe implements PipeTransform {

  transform(value: boolean): string {
    if (value === true) return 'Active';
    if (value === false) return 'Inactive';

    return 'Unknown'; // fallback (good practice)
  }

}