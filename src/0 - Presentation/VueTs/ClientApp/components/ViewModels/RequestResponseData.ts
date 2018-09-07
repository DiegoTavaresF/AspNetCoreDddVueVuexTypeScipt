import { ValidationFailureError } from "./ValidationFailureError"

export class RequestResponseData {

    constructor(errors: string[], validationErrors: ValidationFailureError[]) {
        this.objectResult = {};
        this.errors = errors;
        this.validationErrors = validationErrors;

        this.isValid = errors.length == 0 && validationErrors.length == 0;
    }

    isValid: boolean;
    objectResult: any;
    errors: string[];
    validationErrors: ValidationFailureError[]
}

