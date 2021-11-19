describe("it should visit the app home page", () => {
  it("should visit the home page", () => {
    cy.visit("/");
  });
});

describe("it should  display", () => {
  it("should display welcome text", () => {
    cy.get("h1").should("contain.text", "Willkommen im AKROS Holiday Inn");
  });
});
