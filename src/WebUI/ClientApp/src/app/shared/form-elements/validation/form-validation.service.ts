import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})

export class FormValidationService {

  constructor() { }

  displayFieldCss(field: string, formSubmitAttempt: boolean, formGroup: FormGroup) {
    //if (formSubmitAttempt) {
      return {
        'has-error': this.isFieldValid(field, formSubmitAttempt, formGroup),
        'has-feedback': this.isFieldValid(field, formSubmitAttempt, formGroup)
      };
    //}
  }

  isFieldValid(field: string, formSubmitAttempt: boolean, formGroup: FormGroup) {
    var formField = formGroup.get(field);
    var ret = false;

    //untouched and form submit true  = display error
    //if (formField.untouched && formSubmitAttempt) {
    //  ret = true;
    //}

    //if (!formField.valid && formField.touched || formField.untouched && formSubmitAttempt) {
    //  ret = true;
    //}

    if (formSubmitAttempt && formField.errors) {
      ret = true;
    }

    return ret;
  }

  emailValidator(control) {
    // RFC 2822 compliant regex
    if (control.value.match(/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/)) {
      return null;
    } else {
      return 'Invalid email address';
    }
  }

  passwordValidator(control) {
    // {6,100}           - Assert password is between 6 and 100 characters
    // (?=.*[0-9])       - Assert a string has at least one number
    if (control.value.match(/^(?=.*[0-9])[a-zA-Z0-9!@#$%^&*]{6,100}$/)) {
      return null;
    } else {
      return 'Invalid password. Password must be at least 6 characters long, and contain a number.';
    }
  }

  creditCardValidator(control) {
    // Visa, MasterCard, American Express, Diners Club, Discover, JCB
    if (control.value.match(/^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$/)) {
      return null;
    } else {
      return 'Invalid credit card number';
    }
  }

}
