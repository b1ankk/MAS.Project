import react from '@vitejs/plugin-react-swc';
import { defineConfig } from 'vite';
import mkcert from 'vite-plugin-mkcert';

// https://vitejs.dev/config/
export default defineConfig({
    css: {
        modules: {
            localsConvention: 'camelCase',
        },
    },
    plugins: [react(), mkcert()],
    server: {
        https: true,
        strictPort: true,
        proxy: {
            '/api': { target: 'https://localhost:7076', secure: false },
        },
    },
});
