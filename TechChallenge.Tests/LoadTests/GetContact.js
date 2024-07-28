import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 50,
    duration: '30s',
};
export default function () {
    const url = 'http://localhost:7296/Contact';

    http.get(url);
    sleep(1);
}