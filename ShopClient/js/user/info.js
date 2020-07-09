$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                id: 0,
                username: '',
                birthday: null,
                email: '',
                phone: '',
                createTime: null,
                password: '',
                rePassword: '',
                token: ''
            };
        },
        methods: {
            updateMessage() {
                if (this.password !== this.rePassword) {
                    alert('两次密码不一致!');
                    return;
                } else {
                    axios.post('https://127.0.0.1:44360/api/customer/updatecustomerinfo', {
                        id: this.id,
                        username: this.username,
                        password: this.password,
                        birthday: this.birthday,
                        phone: this.phone,
                        email: this.email,
                        createTime: this.createTime
                    }, {
                        headers: {
                            token: this.token
                        }
                    }).then(function(response) {
                        let data = response.data;
                        if (data.status === 'failed') {
                            alert(data.message);
                        } else {
                            alert(data.message);
                            location.reload();
                        }
                    }).catch(function(error) {
                        console.log(error);
                    });
                }
            }
        }
    });
    let token = window.localStorage.getItem('ShopLoginTOKEN');
    window.vm.token = token;
    axios.post('https://127.0.0.1:44360/api/customer/getcustomerinfo', { }, {
        headers: {
            token
        }
    }).then(function(response) {
        let data = response.data;
        if (data.status === 'failed') {
            alert(data.message);
        } else {
            window.vm.id = data.id;
            window.vm.username = data.username;
            window.vm.birthday = new Date(data.birthday);
            window.vm.email = data.email;
            window.vm.phone = data.phone;
            window.vm.createTime = new Date(data.createTime);
        }
    }).catch(function(error) {
        console.log(error);
    });
    
});