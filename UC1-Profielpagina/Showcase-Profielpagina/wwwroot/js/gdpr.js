class GDPR {

    constructor() {

        if (window.location.pathname === "/Contact/Me") {
            this.showStatus();
            this.showContent();
        }

        if (this.cookieStatus() == null) {
            this.insertGDPR();
            this.bindEvents();
        }
    }

    bindEvents() {
        let buttonAccept = document.querySelector('.gdpr-consent__button--accept');
        buttonAccept.addEventListener('click', () => {
            this.cookieStatus('accept');

            if (window.location.pathname === "/Contact/Me") {
                this.showStatus();
                this.showContent();
            }

            this.hideGDPR();
        });

        let buttonReject = document.querySelector('.gdpr-consent__button--reject');
        buttonReject.addEventListener('click', () => {
            this.cookieStatus('reject');

            if (window.location.pathname === "/Contact/Me") {
                this.showStatus();
                this.showContent();
            }

            this.hideGDPR();
        });


    }

    showContent() {
        this.resetContent();
        const status = this.cookieStatus() == null ? 'not-chosen' : this.cookieStatus();
        const element = document.querySelector(`.content-gdpr-${status}`);
        element.classList.add('show');

    }

    resetContent() {
        const classes = [
            '.content-gdpr-accept',
            '.content-gdpr-reject',
            '.content-gdpr-not-chosen'];

        for (const c of classes) {
            document.querySelector(c).classList.add('hide');
            document.querySelector(c).classList.remove('show');
        }
    }

    showStatus() {
        document.getElementById('content-gpdr-consent-status').innerHTML =
            this.cookieStatus() == null ? 'Niet gekozen' : this.cookieStatus();
    }

    cookieStatus(status) {

        if (status) localStorage.setItem('gdpr-consent-choice', status);

//student uitwerking

        return localStorage.getItem('gdpr-consent-choice');
    }

    insertGDPR() {
        if (document.querySelector('.gdpr-consent')) return;

        const gdprHTML = `
            <section class="gdpr-consent">
    
                <div class="gdpr-consent__description">
                    <p>
                        Deze website gebruikt cookies.
                        We gebruiken cookies om content te personaliseren, voor social media en het analyseren
                        van verkeer op de website en voor advertenties.
                    </p>
                </div>
    
                <div class="gdpr-consent__choice">
                    <button class="gdpr-consent__button--accept">Accepteren</button>
                    <button class="gdpr-consent__button--reject">Weigeren</button>
                </div>
    
            </section>
        `;

        document.body.insertAdjacentHTML('beforeend', gdprHTML);
    }


    hideGDPR() {
        document.querySelector(`.gdpr-consent`).classList.add('hide');
        document.querySelector(`.gdpr-consent`).classList.remove('show');
    }

    showGDPR() {
        document.querySelector(`.gdpr-consent`).classList.add('show');
    }

}

const gdpr = new GDPR();

