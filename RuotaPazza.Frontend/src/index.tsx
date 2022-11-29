import "./index.css";

declare global {
  interface PayPal {
    Donation: {
      Button: (config: {
        env: "sandbox";
        hosted_button_id: string;
        image: {
          src: string;
          title: string;
          alt: string;
        };
        onComplete: (params: {
          tx: string;
          st: "Completed";
          amt: string;
          cc: "EUR";
          cm: unknown;
          item_number: unknown;
          item_name: unknown;
        }) => void;
      }) => {
        render: (selector: string) => void;
      };
    };
  }

  const PayPal: PayPal;
}

PayPal.Donation.Button({
  env: "sandbox",
  hosted_button_id: "BDKZRQCHPDXG6",
  // business: "",
  image: {
    src: "https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif",
    title: "PayPal - The safer, easier way to pay online!",
    alt: "Donate with PayPal button",
  },
  onComplete(params) {
    // TODO: remove this
    console.log("Posting donation", {
      endpoint: "/donations",
      options: { method: "POST", body: { transactionId: params.tx } },
    });

    fetch("/donations", {
      method: "POST",
      body: JSON.stringify({ transactionId: params.tx }),
    })
      .then((response) => response.json())
      .then((response) => console.log(response));
  },
}).render("#paypal-donate-button-container");
