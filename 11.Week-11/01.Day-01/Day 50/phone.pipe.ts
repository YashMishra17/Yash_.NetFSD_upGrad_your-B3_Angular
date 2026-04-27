import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return '';

    // Ensure only digits
    const cleaned = value.replace(/\D/g, '');

    // Format: 9876543210 → 987-654-3210
    if (cleaned.length === 10) {
      return cleaned.replace(/(\d{3})(\d{3})(\d{4})/, '$1-$2-$3');
    }

    return value; // fallback if invalid
  }

}