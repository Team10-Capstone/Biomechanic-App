'use client'

import { useState } from 'react'
import { motion } from 'framer-motion'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Brain, Waves } from 'lucide-react'

export default function Component() {
  const [isLoading, setIsLoading] = useState(false)

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault()
    setIsLoading(true)
    // Simulate API call
    await new Promise(resolve => setTimeout(resolve, 2000))
    setIsLoading(false)
    // Here you would typically handle the sign-up logic and navigation
  }

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-900 relative overflow-hidden font-mono">
      <div className="absolute top-4 left-4 z-20">
        <h1 className="text-4xl font-bold text-white opacity-20 tracking-wider glitch" style={{ textShadow: '2px 2px #ff00ff, -2px -2px #00ffff' }}>BIMLAR</h1>
      </div>
      <div className="absolute inset-0 z-0">
        <div className="absolute inset-0 bg-[linear-gradient(to_right,#80808012_1px,transparent_1px),linear-gradient(to_bottom,#80808012_1px,transparent_1px)] bg-[size:14px_24px]"></div>
        <div className="absolute left-0 right-0 top-[-10%] h-[500px] bg-gradient-to-br from-purple-500 to-blue-500 opacity-20 blur-[100px] z-0"></div>
      </div>
      <motion.div 
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
        className="z-10 w-full max-w-md"
      >
        <div className="bg-gray-800 p-8 rounded-lg shadow-2xl border border-gray-700">
          <div className="flex justify-center mb-8">
            <Logo className="w-16 h-16 text-purple-500" />
          </div>
          <h2 className="text-3xl font-bold text-center text-white mb-6">Create Account</h2>
          <p className="text-gray-400 text-center mb-6">Join our community today</p>
          <form onSubmit={handleSubmit} className="space-y-4">
            <div className="space-y-2">
              <Label htmlFor="name" className="text-gray-300">Name</Label>
              <Input id="name" placeholder="Enter your name" type="text" required className="bg-gray-700 border-gray-600 text-white placeholder-gray-400" />
            </div>
            <div className="space-y-2">
              <Label htmlFor="email" className="text-gray-300">Email</Label>
              <Input id="email" placeholder="Enter your email" type="email" required className="bg-gray-700 border-gray-600 text-white placeholder-gray-400" />
            </div>
            <div className="space-y-2">
              <Label htmlFor="password" className="text-gray-300">Password</Label>
              <Input id="password" placeholder="Create a password" type="password" required className="bg-gray-700 border-gray-600 text-white placeholder-gray-400" />
            </div>
            <Button type="submit" className="w-full bg-purple-600 hover:bg-purple-700 text-white" disabled={isLoading}>
              {isLoading ? (
                <>
                  <Waves className="mr-2 h-4 w-4 animate-spin" />
                  Creating account...
                </>
              ) : (
                'Sign Up'
              )}
            </Button>
          </form>
          <p className="mt-4 text-center text-sm text-gray-400">
            Already have an account?{' '}
            <a href="#" className="text-purple-400 hover:underline">
              Log in
            </a>
          </p>
        </div>
      </motion.div>
      <style jsx>{`
        @keyframes glitch {
          0% {
            text-shadow: 2px 2px #ff00ff, -2px -2px #00ffff;
          }
          25% {
            text-shadow: -2px -2px #ff00ff, 2px 2px #00ffff;
          }
          50% {
            text-shadow: 2px -2px #ff00ff, -2px 2px #00ffff;
          }
          75% {
            text-shadow: -2px 2px #ff00ff, 2px -2px #00ffff;
          }
          100% {
            text-shadow: 2px 2px #ff00ff, -2px -2px #00ffff;
          }
        }
        .glitch {
          animation: glitch 5s infinite;
        }
      `}</style>
    </div>
  )
}

function Logo({ className }: { className?: string }) {
  return (
    <div className={`relative ${className}`}>
      <Brain className="absolute inset-0" />
      <Waves className="absolute inset-0" />
    </div>
  )
}
