const registerform = document.querySelector(".registerform");

registerform.addEventListener('submit', (e) => {
	e.preventDefault();
	const fname = registerform.fname.value;
	const lname = registerform.lname.value;
	const email = registerform.email.value;
	const userData = { CustomerId: -1, Fname: fname, Lname: lname, Email: email }

	//GET fetch request
	fetch('customer/register', {
		method: 'POST',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(userData)
	})
		.then(response => {
			if (!response.ok) {
				throw new Error(`Network response was not ok (${response.status})`);
			}
			else       // When the page is loaded convert it to text
				return response.json();
		})
		.then(res => {
			sessionStorage.setItem('user', JSON.stringify(res));//, json.stringify(res));
			let user = sessionStorage.getItem('user');
			console.log(sessionStorage.user);
			location.href = "Store.html";
		})
		.then((jsonResponse) => {
			//debugger;
			console.log(jsonResponse);
			//registerResponse.textContent
			//registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
			//console.log(jsonResponse);
			location.href = "Store.html";
			return jsonResponse;
		})
		//.then(res => {
		//	//save the personId to localStorage
		//	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
		//	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
		//	//switch the screen
		//	location.href = "Store.html";
	 //location = 'index.html';// 
		//})
		.catch(function (err) {
			console.log('Failed to fetch page: ', err);
		});
});