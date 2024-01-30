import { useState } from "react";

const App = () => {
	const [bffApiError, setBffApiError] = useState<string>();
	const [bffData, setBffData] = useState<string>();
	const [publicApiError, setPublicApiError] = useState<string>();
	const [publicData, setPublicData] = useState<string>();

	const getBffData = async () => {
		try {
			const response = await fetch("/bff/example/get", {
				headers: {
					"X-CSRF": "1",
				},
			});

			if (response.status === 200) {
				const value = await response.text();
				console.log(value);
				setBffData(value);
			}
			else {
				throw new Error(response.status + " - " + response.statusText);
			}
		} catch (error) {
			console.error(error);
			// https://kentcdodds.com/blog/get-a-catch-block-error-message-with-typescript
			const errorMessage: string = (error instanceof Error) ? error.message : String(error);
			setBffApiError(errorMessage);
		}
	};

	const getPublicData = async () => {
		try {
			const response = await fetch("https://api.adviceslip.com/advice");

			if (response.status === 200) {
				const json = await response.json();
				console.log(json.slip.advice);
				setPublicData(json.slip.advice);
			}
			else {
				throw new Error(response.status + " - " + response.statusText);
			}
		} catch (error) {
			console.error(error);
			// https://kentcdodds.com/blog/get-a-catch-block-error-message-with-typescript
			const errorMessage: string = (error instanceof Error) ? error.message : String(error);
			setPublicApiError(errorMessage);
		}
	};

	return (
		<main className="container-sm">
			<h1>Home</h1>
			<h2>Bff api</h2>
			<div className="mb-1">
				<button className="btn btn-outline-dark" onClick={getBffData}>Get</button>
			</div>
			{bffData &&
				<div className="alert alert-info">
					<h3>Result</h3>
					<p>{bffData}</p>
				</div>
			}
			{bffApiError &&
				<div className="alert alert-danger">
					<h3>Error</h3>
					<p>{bffApiError}</p>
				</div>
			}
			<h2>Public api</h2>
			<div className="mb-1">
				<button className="btn btn-outline-dark" onClick={getPublicData}>Get</button>
			</div>
			{publicData &&
				<div className="alert alert-info">
					<h3>Result</h3>
					<p>{publicData}</p>
				</div>
			}
			{publicApiError &&
				<div className="alert alert-danger">
					<h3>Error</h3>
					<p>{publicApiError}</p>
				</div>
			}
			<h2>Bootstrap accordion</h2>
			<div className="accordion" id="accordion-example">
				<div className="accordion-item">
					<h2 className="accordion-header">
						<button aria-controls="accordion-item-body-1" aria-expanded="false" className="accordion-button collapsed" data-bs-target="#accordion-item-body-1" data-bs-toggle="collapse" type="button">
							Accordion Item #1
						</button>
					</h2>
					<div className="accordion-collapse collapse" data-bs-parent="#accordion-example" id="accordion-item-body-1">
						<div className="accordion-body">
							<strong>Accordion Item #1</strong> This is the first item's accordion body.
						</div>
					</div>
				</div>
			</div>
		</main>
	)
};

export default App;