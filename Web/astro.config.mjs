import { defineConfig } from 'astro/config';
import dotenv from 'dotenv';
import htmx from 'astro-htmx';
import icon from 'astro-icon';

dotenv.config();

// https://astro.build/config
export default defineConfig({
    output: 'server',
    integrations: [htmx(), icon()]
});