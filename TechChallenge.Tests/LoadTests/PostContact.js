import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 50,
    duration: '30s',
};
export default function () {
    const url = 'http://localhost:7296/Contact';

    const payload = JSON.stringify({
        "name": "TEST " + Math.floor(100000 + Math.random() * 900000),
        "phone": "81988992277",
        "email": "user" + Math.floor(100000 + Math.random() * 900000) + "@example.com"
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
            "Accept": "application/json"
        },
    };

    http.post(url, payload, params);
    sleep(1);
}