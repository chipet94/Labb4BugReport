describe('My test suite', () => {
    before(() => {
       cy.intercept('GET', 'http://0.0.0.0:5000/BugReport').as('getReports')
   })
    //Städa 
    after(() => {
        cy.request(
            'DELETE',
            'http://0.0.0.0:5000/BugReport/title/Illusions'
        )
    })
    beforeEach(() => {
        cy.visit("http://0.0.0.0:8080/BugReports");
    })

    it('Submit a bugreport', () => {
        cy.visit("http://0.0.0.0:8080/BugReports");
        //expandera ny rapport rutan
        cy.get('#addReportButton').click()
        //variabler
        cy.get('#title').type('Illusions')
        cy.get('#name').clear().type('cypress-hill')
        cy.get('#description').type("Some people tell me that I need help\n" +
            "Some people can !&#* off and go to hell")
        //skicka rapport
        cy.get("#submitReportBtn").click()
        //bekräfta genom att kolla om sista rapporten har titeln "Illusions"
        cy.get('[id^=report-]').last("[id^=report-] > :nth-child(1)").should("contain", 'Illusions')
    })
})
