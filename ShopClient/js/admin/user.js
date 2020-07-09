$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                list: []
            };
        },
        methods: {
            
        }
    });
    let token = window.localStorage.getItem('ShopAdminLoginTOKEN');
    axios.post('https://127.0.0.1:44360/api/administrator/getallcustomers', { }, {
        headers: {
            token
        }
    }).then(function(response) {
        let data = response.data;
        window.vm.list = data;
    }).catch(function(error) {
        console.log(error);
    });
});