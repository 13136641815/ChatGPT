const AxiosPromise = function (Url, Method, Data = {}, NoLoding = false) {
    return new Promise((resolve, reject) => {
        let _Method = '';
        let AxiosObj = {};
        if (Method == 'post' || Method == 'POST' || Method == 'put' || Method == 'PUT') {
            AxiosObj = {
                method: Method,
                url: Url,
                data: Data,
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                    'No-Loding': NoLoding
                },
            }
        } else {
            AxiosObj = {
                method: Method,
                url: Url,
                params: Data,
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8',
                    'No-Loding': NoLoding
                },
            }
        }
        axios(AxiosObj).then(res => {
            resolve(res);
        }).catch(err => {
            reject(err);
        })
    })
}
const AxiosAsync = function (Url, Method, Data = {}, NoLoding = false) {
    let _Method = '';
    let AxiosObj = {};
    if (Method == 'post' || Method == 'POST' || Method == 'put' || Method == 'PUT') {
        AxiosObj = {
            method: Method,
            url: Url,
            data: Data,
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
                'No-Loding': NoLoding
            },
        }
    } else {
        AxiosObj = {
            method: Method,
            url: Url,
            params: Data,
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
                'No-Loding': NoLoding
            },
        }
    }
    return axios(AxiosObj);
}