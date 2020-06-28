/* Set up all the momentjs interop stuff */
/// <reference path="types/moment.d.ts" />

class MomentJsInterop {

    public getAvailableMomentLocales(): string[] {
        return moment.locales();
    }

    public getCurrentLocale(): string {
        return moment.locale();
    }

    public changeLocale(locale: string) {
        if (typeof locale !== 'string') {
            throw 'locale must be a string';
        }
        let cur = this.getCurrentLocale();

        // if the current locale is the one requested, we don't need to do anything
        if (locale === cur) return false;

        // set locale
        let newL = moment.locale(locale);

        // if the new locale is the same as the old one, it was not changed - probably because momentJs didn't find that locale
        if (cur === newL) throw 'the locale \'' + locale + '\' could not be set. It was probably not found.';

        return true;
    }
}