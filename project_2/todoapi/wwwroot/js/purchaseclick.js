const registerform = document.getElementsByClassName('purchaseclicks')[0];
registerform.addEventListener('click', (e) => {

	e.preventDefault();

	const listoftwo = [];

		for (let x = 0; x < sessionStorage.counter; x++) {
			var cartonebyone = JSON.parse(localStorage.getItem('cart' + parseInt(x + 1)));
			var two2 = {
				"fname": "string",
				"lname": "string",
				"email": "string",
				"passwordH": "string",
				"customerId": Number(cartonebyone.CustomerId),
				"itemizedId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
				"orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
				"storeProductId": 1,
				"productId": Number(cartonebyone.ProductId),
				"orderDate": "2021-09-21T06:19:38.009Z",
				"productName": "string",
				"productDescription": "string",
				"productPrice": 10,
				"productPicture": "string",
				"productQuantity": 10,
				"storeId": Number(cartonebyone.StoreId),
				"storeName": "string",
				"storeguidId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
				"authorBiographies": "string"
			};
			listoftwo.push(two2);
		}
		console.log(listoftwo);

		//console.log(two2);
		//GET fetch request
		fetch('/ViewAll/purchasevA', {
			method: 'post',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(two2)
		})
			.then(response => {
				if (!response.ok) {
					throw new Error(`Network response was not ok (${response.status})`);
				}
				else       // When the page is loaded convert it to text
				{

	localStorage.clear();
	localStorage.setItem('user', sessionStorage.getItem('user'));
	sessionStorage.clear();
	sessionStorage.setItem('user', localStorage.getItem('user'));
	localStorage.clear();
	location.href = "Store.html";
					return response.json();
				}
			})
			.catch(function (err) {
				console.log('Failed to fetch page: ', err);
			});

		
	});

	//localStorage.clear();
	//localStorage.setItem('user', sessionStorage.getItem('user'));
	//sessionStorage.clear();
	//sessionStorage.setItem('user', localStorage.getItem('user'));
	//localStorage.clear();
	//location.href = "Store.html";













//const registerform = document.getElementsByClassName('purchaseclicks')[0];

//registerform.addEventListener('click', (e) => {
//	e.preventDefault();
//	var cartonebyone = JSON.parse(localStorage.getItem('cart1'));

//	var two2 = {
//		"fname": "string",
//		"lname": "string",
//		"email": "string",
//		"passwordH": "string",
//		"customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//		"itemizedId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//		"orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//		"storeProductId": 1,
//		"productId": cartonebyone.ProductId,
//		"orderDate": "2021-09-21T06:19:38.009Z",
//		"productName": "string",
//		"productDescription": "string",
//		"productPrice": 10,
//		"productPicture": "string",
//		"productQuantity": 10,
//		"storeId": cartonebyone.StoreId,
//		"storeName": "string",
//		"storeguidId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//		"authorBiographies": "string"
//	};
//	//console.log(userData);
//	//GET fetch request
//	fetch('/ViewAll/purchasevA', {
//		method: 'post',
//		headers: {
//			'Accept': 'application/json',
//			'Content-Type': 'application/json'
//		},
//		body: JSON.stringify(two2)
//	})
//		.then(response => {
//			if (!response.ok) {
//				throw new Error(`Network response was not ok (${response.status})`);
//			}
//			else       // When the page is loaded convert it to text
//				return response.json();
//		})
//		.then(res => {
//			sessionStorage.setItem('user', JSON.stringify(res));//, json.stringify(res));
//			let user = sessionStorage.getItem('user');
//			console.log(sessionStorage.user);
//			location.href = "Store.html";
//		})
//		.then((jsonResponse) => {
//			//debugger;
//			console.log(jsonResponse);
//			//registerResponse.textContent
//			//registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
//			//console.log(jsonResponse);
//			location.href = "Store.html";
//			return jsonResponse;
//		})
//		//.then(res => {
//		//	//save the personId to localStorage
//		//	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
//		//	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
//		//	//switch the screen
//		//	location.href = "Store.html";
//		//location = 'index.html';// 
//		//})
//		.catch(function (err) {
//			console.log('Failed to fetch page: ', err);
//		});
//});
