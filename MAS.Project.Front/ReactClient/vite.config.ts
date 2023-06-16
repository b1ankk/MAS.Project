import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
import mkcert from "vite-plugin-mkcert";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), mkcert()],
  server: {
    https: true,
    strictPort: true,
    proxy: {
      '/api': { target: 'https://localhost:7076', secure: false }
    }
  }
})
