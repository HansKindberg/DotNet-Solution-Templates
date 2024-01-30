import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./style/site.scss";
import "bootstrap/dist/js/bootstrap.bundle.min.js";

ReactDOM.createRoot(document.getElementById('root')!).render(
	<React.StrictMode>
		<App />
	</React.StrictMode>
)